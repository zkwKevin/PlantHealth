import React, { Component } from 'react'


class ShowTarget extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoading: true,
            targetItems: [],
            error: null,
            
        };
    }

    fetchTargetItems(){
        fetch('https://localhost:5001/api/targetItems')
        .then(response =>response.json())
        .then(data =>
            this.setState({
                targetItems : data,
                isLoading : false,
            })
        )
        .catch(error => this.setState({error : error, isLoading : false}));
    }

    componentDidMount() {
        this.fetchTargetItems();
    }
    
    render() {
        const { isLoading, targetItems, error} = this.state;
       
        return (
            <React.Fragment>
                <h1>targetItems for show</h1>
                { error ? <p>{error.message}</p> : null}

                {! isLoading ? 
                    Object.keys(targetItems).map(key => 
                        <TargetItem key={key} body={targetItems[key]}/>) : <h3>Loading...</h3>
                } 
            </React.Fragment>
        )
    }
}

// const TargetItem = ({body}) => {
//     return (
//         <div>             
//             <h2>{body.name}</h2>
//             <p>{body.type}</p>
//             <hr />            
//         </div>
//     );
// };

class TargetItem extends Component {
    render() {
        return (
            <div>             
            <h2>{this.props.body.name}</h2>
            <p>{this.props.body.type}</p>
            <hr />            
        </div>
        )
    }
}

 
  
  
export default ShowTarget;