import React, { Component } from 'react';
import { connect} from 'react-redux';
import { targetActions } from '../_actions/target.actions';
import { styleActions } from '../_actions/style.actions';
import { Link } from 'react-router-dom';

class AnimalPage extends Component{
	constructor(props){
		super(props);
		this.props.dispatch(styleActions.changeLinkStyleToAnimal());
		
	}
	componentDidMount() {
        this.props.dispatch(targetActions.getAnimalList(this.props.user.id));
    }

	
	render(){
		const { animals, loading , user} = this.props;
		return(
			
			<div className="col-me-6 col-md-offset-3">
				<h1>Animal</h1>
				<button>+ADD</button>
				{/* add button to switch to Live mode */}
				
				<h3>All Animals:</h3>
                { loading && <em>Loading Animals...</em>}
                { animals ? 
					<ul>
						{
							animals.map((animal, index) =>
								<li key={animal.id}>
									{ animal.name }
									{ animal.logs.map((log, index) =>
										<li key = {log.id}>
										{log.todoItem.name}
										</li>
									) }
								</li>
										
						)}
					</ul> : <em>Empty</em> }
			</div>
		);
	}
}

function mapStateToProps(state) {
	const { target, authentication } = state;
	const { animals, loading } = target;
	const { user } = authentication;
	return {
		animals,
		loading,
		user
	};
}

const connectedAnimalPage = connect(mapStateToProps)(AnimalPage);
export { connectedAnimalPage as AnimalPage };
