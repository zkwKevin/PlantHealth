import React, { Component } from 'react';
import { connect} from 'react-redux';
import { targetActions } from '../_actions/target.actions';
import { styleActions } from '../_actions/style.actions';
import { Link } from 'react-router-dom';
import {
	Button,
	Form,
	Grid,
	Header,
	Container,
	Segment,
	Table,
	Checkbox,
	Label,
	Divider,
	Select,
	Icon,
	Card,
	CardDescription,
	Tab
  } from 'semantic-ui-react';

class AnimalPage extends Component{
	constructor(props){
		super(props);
		this.props.dispatch(styleActions.changeLinkStyleToAnimal());
		this.state = {
			showRemove: false
		}
		
	}
	componentDidMount() {
        this.props.dispatch(targetActions.getAnimalList(this.props.user.id));
	}
	
	handleToggle() {
		const { showRemove } = this.state;
		this.setState({
			showRemove: !showRemove
		})
	}

	
	render(){
		const { animals, loading , user} = this.props;
		const { showRemove } = this.state;
		return(	
			<Grid>
				<Grid.Row>
					<Grid columns={2} textAlign="center" >																	
						<Table basic='very'>
							<Table.Body>
								<Table.Row >								
									<Table.Cell >
										<h1>Animal</h1>
									</Table.Cell>
									<Table.Cell colSpan='4'>								
									<Button
										floated='right'
										icon
										labelPosition='left'
										primary
										size='small'
									>
										<Icon name='add' /> Add
									</Button>	
									</Table.Cell>
								</Table.Row>
							</Table.Body>
						</Table>
						<Divider/>												
					</Grid>
				</Grid.Row>

				{animals && 
					 <Grid celled='internally'>
					 {animals.map((animal, index) =>
						 <Grid.Row key={animal.id}>
							<Grid.Column textAlign='center' width={4}>
								<Card>
									{/* <Image src='/images/avatar/large/matthew.png' /> */}
									<Card.Content>
										<Card.Header>{animal.name}</Card.Header>
										<Card.Meta>
											<span className='date'>Joined in 2015</span>
										</Card.Meta>			
										{showRemove &&
											<CardDescription>									
												<Button
														color='red'
														icon
														labelPosition='left'
														size='small'	
													>
														<Icon name='trash' /> remove
												</Button>
											</CardDescription>	
										}	
									</Card.Content>
								</Card>
							</Grid.Column>

 							<Grid.Column textAlign='center' width={12}>
					
								<Table  stackable color="yellow">
									<Table.Header fullWidth>
									<Table.Row>
										<Table.HeaderCell>Action</Table.HeaderCell>
										<Table.HeaderCell>Description</Table.HeaderCell>
										{showRemove &&
											<Table.HeaderCell>Remove</Table.HeaderCell>
										}
										
									</Table.Row>
									</Table.Header>

									{ animal && 
										<Table.Body>
											{animal.logs.map((log, index) => 
												<Table.Row key={log.id}>
													{ log && 
														<Table.Cell>
															{log.todoItem.name}
														</Table.Cell>
													
													}

													{ log && log.todoItem.time == 1 ?
														<Table.Cell>
															{log.todoItem.timesForMode} times / {log.todoItem.mode}
														</Table.Cell>	:
														<Table.Cell>
															{log.todoItem.timesForMode} times / {log.todoItem.time} {log.todoItem.mode}s
														</Table.Cell>		
													}

													{log && showRemove &&
														<Table.Cell>
															<Button basic color="red" icon="trash" size="small" />
														</Table.Cell>
													}
													
													
												</Table.Row>
												
											)}
										</Table.Body>
									}
							
									<Table.Footer fullWidth>
									<Table.Row>
									
										<Table.HeaderCell >
										<Checkbox toggle label="Edit" onChange={()=> this.handleToggle()}/>
										</Table.HeaderCell>
										<Table.HeaderCell colSpan='4'>
										<Button
											floated='right'
											icon
											labelPosition='left'
											primary
											size='small'
										>
											<Icon name='user' /> Add Action
										</Button>
										</Table.HeaderCell>
									</Table.Row>
									</Table.Footer>
								</Table>							
							</Grid.Column>	 
						 </Grid.Row>	 
					 )}
				 	</Grid>
				}
			</Grid>
			// <Grid>
				// <Grid.Row>
				// 	<Grid columns={2} textAlign="center" >																	
				// 		<Table basic='very'>
				// 			<Table.Body>
				// 				<Table.Row >								
				// 					<Table.Cell >
				// 						<h1>Animal</h1>
				// 					</Table.Cell>
				// 					<Table.Cell colSpan='4'>								
				// 					<Button
				// 						floated='right'
				// 						icon
				// 						labelPosition='left'
				// 						primary
				// 						size='small'
				// 					>
				// 						<Icon name='add' /> Add
				// 					</Button>	
				// 					</Table.Cell>
				// 				</Table.Row>
				// 			</Table.Body>
				// 		</Table>
				// 		<Divider/>												
				// 	</Grid>
				// </Grid.Row>
				
			// 		{ animals? <ul>{
			// 			animals.map((animal, index) =>
			// 			{
			// 				<li key={animal.id}>
			// 					{ animal.name }	
			// 				</li>
			// 				// <Grid.Row>
							// 	<Grid.Column textAlign='center' width={4}>
							// 		<Card>
							// 			{/* <Image src='/images/avatar/large/matthew.png' /> */}
							// 			<Card.Content>
							// 				<Card.Header>{animal.name}</Card.Header>
							// 				<Card.Meta>
							// 					<span className='date'>Joined in 2019</span>
							// 				</Card.Meta>
							// 				<Card.Description>{animal.name} is my best friend.</Card.Description>			
							// 				{showRemove &&
							// 					<Button
							// 							color='red'
							// 							icon
							// 							labelPosition='left'
							// 							size='small'	
							// 						>
							// 							<Icon name='trash' /> remove
							// 					</Button>
							// 				}	
							// 			</Card.Content>
							// 		</Card>
							// 	</Grid.Column>
			// 				// </Grid.Row>
							
			// 			}
			// 		)
			// 		}</ul>: <em>Empty</em>}
				
			// </Grid>
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
