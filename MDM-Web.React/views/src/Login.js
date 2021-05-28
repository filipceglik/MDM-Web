import logo from './logo.svg';
import './App.css';
import 'bootstrap'
import 'react-bootstrap'
import Form from "react-bootstrap/Form"
import Button from "react-bootstrap/Button"
import Card from "react-bootstrap/Card"
import "./css/Login.css"
import {useState} from "react";


function Login(){
    
    return(
        <div className="container Login">
            <div className="row">
                <div className="col-12">
                    <Form className="login-form card shadow-sm p-3">
                        <Form.Group size="lg" controlId="email">
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="email" />
                        </Form.Group>
                        <Form.Group size="lg" controlId="password">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" />
                        </Form.Group>
                        <Form.Group>
                            <Button block size="lg" type="submit">
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
