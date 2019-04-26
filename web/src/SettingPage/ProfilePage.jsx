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
                <Segment  color='yellow'>
                
                    <Form size="large" >
                        <Form.Field  >
                            <label>User name:</label>
                            <Segment>1</Segment>
                        </Form.Field>
                        <Form.Field  >
                            <label >Email:</label>
                            <Segment>1</Segment>
                        </Form.Field>

                        <label>Birth:</label>
                        <Form.Group widths='equal'>
                            <Form.Field  >
                                <label >Day:</label>
                                <Segment>1</Segment>
                            </Form.Field>
                            <Form.Field  >
                                <label >Month:</label>
                                <Segment>1</Segment>
                            </Form.Field>
                            <Form.Field  >
                                <label >Year:</label>
                                <Segment>1</Segment>
                            </Form.Field>
                        </Form.Group>
                        
                        <Form.Field  >
                            <label >Gender:</label>
                            <Segment>1</Segment>
                        </Form.Field>
                        
                    </Form>
                </Segment>		
		
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
