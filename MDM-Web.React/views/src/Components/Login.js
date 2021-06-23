import 'bootstrap'
import 'react-bootstrap'
import Form from "react-bootstrap/Form"
import Button from "react-bootstrap/Button"
import "../css/Login.css"
import React, {useState} from "react";
import {useAppContext} from "../libs/contextLib";
import Cookies from "universal-cookie";
import {useHistory} from "react-router-dom";
import LoaderButton from "./LoaderButton";
import {useFormFields} from "../libs/hooksLib";

function Login() {
    const history = useHistory();
    const {userHasAuthenticated} = useAppContext();
    const [isLoading, setIsLoading] = useState(false);

    const [fields, handleFieldChange] = useFormFields({
        email: "",
        password: ""
    });

    function validateForm() {
        return  fields.email.length > 0 && fields.password.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();

        setIsLoading(true)

        if (validateForm()) {
            const cookie = new Cookies()
            cookie.set('User', {email: fields.email})
            userHasAuthenticated(true);
            history.push("/");
        } else {
            alert("Błędne dane")
            setIsLoading(false)
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
                                          value={fields.email}
                                          onChange={handleFieldChange}
                            />
                        </Form.Group>
                        <Form.Group size="lg" controlId="password">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password"
                                          value={fields.password}
                                          onChange={handleFieldChange}
                            />
                        </Form.Group>
                        <Form.Group>
                            <LoaderButton
                                block
                                size="lg"
                                type="submit"
                                isLoading={isLoading}
                                disabled={!validateForm()}
                            >
                                Login
                            </LoaderButton>
                        </Form.Group>
                    </Form>
                </div>
            </div>

        </div>
    )
}

export default Login;
