import React, { Component } from 'react'
import { Redirect } from 'react-router-dom';
class AddTarget extends Component{
    constructor(props){
      super(props);
      this.state = {
        Name: '',
        Type: '',
        redirect: false,
        id:''
      };
    }

    handleNameChange(e) {
      this.setState({Name: e.target.value});
    }
  
    handleTypeChange(e) {
      this.setState({Type: e.target.value});
    }

    handleFormSubmit(e) {
      e.preventDefault(); 
      fetch('https://localhost:5001/api/targetItems', {
        method: 'post',
        headers: new Headers({
          "Content-Type": "application/json",
        }),
        body: JSON.stringify({
          Name: this.state.Name,
          Type: this.state.Type
        })
      })
      // .then((response) => {
      //   if(response.ok) {
      //     response.json().then(data => console.log(data));       
      //   } else {
      //     alert(response.statusText);
      //   }
      // })
      // .then(data => this.setState({redirect : true, id: data.id}));
      .then((response) => {
        if(response.ok) {
          var JSONdata = response.json();
          this.setState({redirect : true, id: JSONdata.id})    
        } else {
          alert(response.statusText);
        }
      })
    }

    render() {
      if (this.state.redirect) {
        return <Redirect to={{
          pathname: "/target/:id",
          state:  { referrer: this.state.id }
        }} />;
      }
      return (
        <div>
          <form onSubmit={(e) => this.handleFormSubmit(e)}>
            <div className="row">
              <label >Name</label>
              <input type="text" name="Name" value={this.state.Name}
                onChange={(e) => this.handleNameChange(e)}/>
            </div>
            <div className="row">
              <h3 >Type</h3>
              <label >
                <input type="radio" name="Type" value="Animal"
                onChange={(e) => this.handleTypeChange(e)}/>Animal
              </label>
              <label >
                <input type="radio" name="Type" value="Plant"
                onChange={(e) => this.handleTypeChange(e)}/>Plant
              </label>
            </div>
            <div className="row">
              <input type="submit" value="Create target"/>
            </div>
          </form>
        </div>
      );
    }
  
}



export default  AddTarget