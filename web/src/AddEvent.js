import React from 'react'

var panelStyle = {
	'max-width': '80%',
	margin: '0 auto'
}

const AddEvent = () => (
  <div>
    <div class="panel panel-primary" style={panelStyle}>
      <div class="panel panel-heading">React Forum - Register</div>
      <div class="panel panel-body">
        <form onsubmit="return false;">
          <strong>Username:</strong> <br /> <input type="text" name="username" placeholder="Nathaniel" /> <br />
          <strong>Email:</strong> <br /> <input type="email" name="email" placeholder="me@example.com" /> <br />
          <strong>Confirm Email:</strong> <br /> <input type="email" name="confirmemail" placeholder="me@example.com" /> <br />
          <strong>Password:</strong> <br /> <input type="password" name="password" placeholder="********" /> <br />
          <strong>Confirm Password:</strong> <br /> <input type="password" name="confirmpassword" placeholder="********" /> <br /><br />
          <button class="btn btn-primary">Register Account</button>
        </form>
      </div>
    </div>
  </div>
)

export default  AddEvent