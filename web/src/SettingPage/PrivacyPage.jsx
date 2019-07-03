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

class PrivacyPage extends Component{
	
	render(){
  
		return (
            <Grid.Column  width={12}>
				<Grid.Row>
					<Grid columns={2} >		
                            <Grid.Column textAlign='center' width={12}>
                            <Container textAlign='left'><h1>Privacy</h1></Container>
                            </Grid.Column>
                            <Grid.Column textAlign='center' width={4}>
                            </Grid.Column>
					</Grid>
				</Grid.Row>
					
                <Grid.Row centered >
                    <Segment  color='orange'>
                    <Container textAlign='center'><h3>Change Your Password</h3></Container>
                    
                        <Form size="large" >
                            <Form.Field  >
                                <label>New Password:</label>
                                <input placeholder="password"/>
                            </Form.Field>
                            <Button color="blue" fluid size="large">
                                Submit
                            </Button>
                            
                        </Form>
                    </Segment>
                </Grid.Row>
					
			</Grid.Column>
				
		
		)
	}
}

export { PrivacyPage };
