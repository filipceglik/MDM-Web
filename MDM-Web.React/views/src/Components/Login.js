import 'bootstrap'
import 'react-bootstrap'
import Form from "react-bootstrap/Form"
import Button from "react-bootstrap/Button"
import "../css/Login.css"
import {useState} from "react";
import {useAppContext} from "../libs/contextLib";
import Cookies from "universal-cookie";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const {userHasAuthenticated} = useAppContext();

    function validateForm() {
        return email.length > 0 && password.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();
        if (validateForm()) {
            const cookie = new Cookies()
            cookie.set('User', {email: email})
            userHasAuthenticated(true);
        }else {
            alert("Błędne dane")
        }
    }

    return (
        <div className="container Login">
            <div className="row">
                <div className="col-12">
                    <Form className="login-form card shadow-sm p-3" onSubmit={handleSubmit}>
                        <Form.Group size="lg" controlId="email">
                            <Form.Label>Email</Form.Label>
                            <Form.Control autoFocus
                                          type="email"
                                          value={email}
                                          onChange={(e) => setEmail(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group size="lg" controlId="password">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password"
                                          value={password}
                                          onChange={(e) => setPassword(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group>
                            <Button block size="lg" type="submit" disabled={!validateForm()}>
                                Login
                            </Button>
                        </Form.Group>
                    </Form>
                </div>
            </div>

        </div>
    )
}

export default Login;
