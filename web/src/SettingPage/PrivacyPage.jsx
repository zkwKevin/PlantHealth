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

class ProfilePage extends Component{
	
	render(){
  
		return (
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
                    <Segment  color='yellow'>
                    
                        <Form size="large" >
                            <Form.Field  >
                                <label>Password:</label>
                                <Segment>1</Segment>
                            </Form.Field>
                            
                        </Form>
                    </Segment>
                </Grid.Row>
					
			</Grid.Column>
				
		
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

const connectedProfilePage = connect(mapStateToProps)(ProfilePage);
export { connectedProfilePage as ProfilePage };
