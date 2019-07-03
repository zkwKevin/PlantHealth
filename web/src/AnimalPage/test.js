<Grid>
				<Grid.Row>
					<Grid columns={2} textAlign="center" >																	
						<Table basic='very'>
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
						</Table>
						<Divider/>												
					</Grid>
				</Grid.Row>
				{ loading && <em>Loading Animals...</em> }
				{ animals ? 
					<div>
						{
							animals.map((animal, index) => 
							{
							<Grid.Row>
								<Grid.Column textAlign='center' width={4}>
									<Card>
										{/* <Image src='/images/avatar/large/matthew.png' /> */}
										<Card.Content>
											<Card.Header>{animal.name}</Card.Header>
											<Card.Meta>
												<span className='date'>Joined in 2019</span>
											</Card.Meta>
											<Card.Description>{animal.name} is my best friend.</Card.Description>			
											{showRemove &&
												<Button
														color='red'
														icon
														labelPosition='left'
														size='small'	
													>
														<Icon name='trash' /> remove
												</Button>
											}	
										</Card.Content>
									</Card>
								</Grid.Column>
							

								<Grid.Column textAlign='center' width={12}>					
									<Table  stackable color="yellow">
										<Table.Header fullWidth>
										<Table.Row>
											<Table.HeaderCell>Action</Table.HeaderCell>
											<Table.HeaderCell>Detail</Table.HeaderCell>
											{showRemove &&
												<Table.HeaderCell>Remove</Table.HeaderCell>
											}
											
										</Table.Row>
										</Table.Header>

										<Table.Body>
											<Table.Row>
												<Table.Cell>John Lilki</Table.Cell>
												<Table.Cell>September 14, 2013</Table.Cell>
												{showRemove &&
													<Table.Cell><Button basic color="red" icon="trash" size="small" /></Table.Cell>
												}										
											</Table.Row>		
										</Table.Body>

										<Table.Footer fullWidth>
										<Table.Row>				
											<Table.HeaderCell >
											<Checkbox toggle onChange={()=> this.handleToggle()}/>
											</Table.HeaderCell>
											<Table.HeaderCell colSpan='4'>
											<Button
												floated='right'
												icon
												labelPosition='left'
												primary
												size='small'
											>
												<Icon name='user' /> Add User
											</Button>
											</Table.HeaderCell>
										</Table.Row>
										</Table.Footer>
									</Table>
								</Grid.Column>
							</Grid.Row>	
							})}				
							</div>: <em>Empty</em> } }	
						</Grid>










					// 			<li key={animal.id}>
					// 				{ animal.name }
					// 				{ animal.logs.map((log, index) =>
					// 					<li key = {log.id}>
					// 					{log.todoItem.name}
					// 					</li>
					// 				) }
					// 			</li>
										
					// 	)}
					// </ul> : <em>Empty</em> } */}
		// 		<Grid.Row>
		// 			<Grid.Column textAlign='center' width={4}>
		// 				<Card>
		// 					{/* <Image src='/images/avatar/large/matthew.png' /> */}
		// 					<Card.Content>
		// 						<Card.Header>Matthew</Card.Header>
		// 						<Card.Meta>
		// 							<span className='date'>Joined in 2015</span>
		// 						</Card.Meta>
		// 						<Card.Description>Matthew is a musician living in Nashville.</Card.Description>			
		// 						{showRemove &&
		// 							<Button
		// 									color='red'
		// 									icon
		// 									labelPosition='left'
		// 									size='small'	
		// 								>
		// 									<Icon name='trash' /> remove
		// 							</Button>
		// 						}	
		// 					</Card.Content>
		// 				</Card>
		// 			</Grid.Column>

		// 			<Grid.Column textAlign='center' width={12}>
					
		// 				<Table  stackable color="yellow">
		// 					<Table.Header fullWidth>
		// 					<Table.Row>
		// 						<Table.HeaderCell>Action</Table.HeaderCell>
		// 						<Table.HeaderCell>Detail</Table.HeaderCell>
		// 						{showRemove &&
		// 							<Table.HeaderCell>Remove</Table.HeaderCell>
		// 						}
								
		// 					</Table.Row>
		// 					</Table.Header>

		// 					<Table.Body>
		// 					<Table.Row>
							
		// 						<Table.Cell>John Lilki</Table.Cell>
		// 						<Table.Cell>September 14, 2013</Table.Cell>
		// 						{showRemove &&
		// 							<Table.Cell><Button basic color="red" icon="trash" size="small" /></Table.Cell>
		// 						}
								
		// 					</Table.Row>
		// 					<Table.Row>
							
		// 						<Table.Cell>Jamie Harington</Table.Cell>
		// 						<Table.Cell>January 11, 2014</Table.Cell>
		// 						{showRemove &&
		// 							<Table.Cell><Button basic color="red" icon="trash" size="small" /></Table.Cell>
		// 						}
		// 					</Table.Row>
		// 					<Table.Row>
							
		// 						<Table.Cell>Jill Lewis</Table.Cell>
		// 						<Table.Cell>May 11, 2014</Table.Cell>
		// 						{showRemove &&
		// 							<Table.Cell><Button basic color="red" icon="trash" size="small" /></Table.Cell>
		// 						}
		// 					</Table.Row>
		// 					</Table.Body>

		// 					<Table.Footer fullWidth>
		// 					<Table.Row>
							
		// 						<Table.HeaderCell >
		// 						<Checkbox toggle onChange={()=> this.handleToggle()}/>
		// 						</Table.HeaderCell>
		// 						<Table.HeaderCell colSpan='4'>
		// 						<Button
		// 							floated='right'
		// 							icon
		// 							labelPosition='left'
		// 							primary
		// 							size='small'
		// 						>
		// 							<Icon name='user' /> Add User
		// 						</Button>
		// 						</Table.HeaderCell>
		// 					</Table.Row>
		// 					</Table.Footer>
		// 				</Table>
		// 			</Grid.Column>
		// 		</Grid.Row>
		// 		<Divider/>		
		// </Grid>
				/* <h3>All Animals:</h3>
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
					</ul> : <em>Empty</em> } */