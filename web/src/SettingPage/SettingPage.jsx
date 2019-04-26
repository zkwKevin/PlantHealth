import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions'
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
	Menu,
	Label,
	Divider,
	Select
  } from 'semantic-ui-react';
  import { BirthArray } from './BirthOptions';
  import { ProfilePage } from './ProfilePage';

class SettingPage extends Component{
	constructor(props)
	{
		super(props);
		this.state = { isEdit:false };
	}


	handleClick(){
		const {isEdit} = this.state;
		this.setState({isEdit:!isEdit});
	}

	render(){

		const { isEdit } = this.state;
		const genderOptions = [
			{ key: 'm', text: 'Male', value: 'male' },
			{ key: 'f', text: 'Female', value: 'female' },
		]
		var monthNameList = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

		
		const dayOptions = BirthArray.dateArray(1,32);
		const monthOptions = BirthArray.monthArray(monthNameList);
		const yearOptions = BirthArray.dateArray(1950,2020);

  
		return (
			<Grid columns={2}>	
				<Grid.Column textAlign='center' width={4}>
					<Menu fluid vertical >
					<Menu.Item >Profile</Menu.Item>
					<Menu.Item>Privacy</Menu.Item>
					</Menu>
				</Grid.Column>
				<Grid.Column  width={12}>
					<Grid.Row>
						<Grid columns={2} >		
								<Grid.Column textAlign='center' width={12}>
								<Container textAlign='left'><h1>Profile</h1></Container>
								</Grid.Column>
								<Grid.Column textAlign='center' width={4}>
									<Container textAlign='right'><Checkbox toggle label="Edit" onChange={()=> this.handleClick()}/></Container>
								</Grid.Column>
						</Grid>
					</Grid.Row>
					
					<Grid.Row centered >
					{isEdit?
					(
						<Segment  color='yellow'>
						
							<Form size="large" >
								<Form.Field  >
									<label>User name:</label>
									<input placeholder='User name' />
								</Form.Field>
								<Form.Field  >
									<label >Email:</label>
									<input placeholder='Email'  />
								</Form.Field>

								<label>Birth:</label>
								<Form.Group widths='equal'>
									<Form.Field
										fluid
										control={Select}
										options={dayOptions}
										label={{ children: 'Day', htmlFor: 'form-select-control-day' }}
										placeholder='Day'
										search
										searchInput={{ id: 'form-select-control-day' }}
									/>
									<Form.Field
										fluid
										control={Select}
										options={monthOptions}
										label={{ children: 'Month', htmlFor: 'form-select-control-month' }}
										placeholder='Month'
										search
										searchInput={{ id: 'form-select-control-month' }}
									/>
									<Form.Field
										fluid
										control={Select}
										options={yearOptions}
										label={{ children: 'Year', htmlFor: 'form-select-control-year' }}
										placeholder='Year'
										search
										searchInput={{ id: 'form-select-control-year' }}
									/>
								</Form.Group>
								
								<Form.Field
									control={Select}
									options={genderOptions}
									label={{ children: 'Gender', htmlFor: 'form-select-control-gender' }}
									placeholder='Gender'
									search
									searchInput={{ id: 'form-select-control-gender' }}
								/>

								{isEdit&& 
									<Button color="blue" fluid size="large">
										Submit
									</Button>
								}
							</Form>
							</Segment>		
						)
						:<ProfilePage/>}
					</Grid.Row>
					
				</Grid.Column>
			</Grid>
		
		)
	}
}

function mapStateToProps(state) {
	const { authentication} = state;
	const { user } = authentication;
	return {
		user,
	};
}

const connectedSettingPage = connect(mapStateToProps)(SettingPage);
export { connectedSettingPage as SettingPage };
/* <Form.Input
									fluid
									icon="lock"
									iconPosition="left"
									placeholder="Password"
									type="password"
									readOnly
								/> */
