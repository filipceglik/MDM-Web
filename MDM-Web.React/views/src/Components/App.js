import 'bootstrap'
import 'react-bootstrap'
import Navbar from "react-bootstrap/Navbar";
import Routes from "../Routes";
import {AppContext} from "../libs/contextLib";
import {useEffect, useState} from "react";
import {LinkContainer} from "react-router-bootstrap";
import Nav from "react-bootstrap/Nav";
import Cookies from "universal-cookie";

function App() {
    const [isAuthenticated, userHasAuthenticated] = useState(false);

    function handleLogout(event) {
        event.preventDefault()
        const cookies = new Cookies()
        cookies.remove("User")
        userHasAuthenticated(false);
    }

    const [isAuthenticating, setIsAuthenticating] = useState(true);
    useEffect(() => {
        onLoad();
    }, []);

    async function onLoad() {
        const cookies = new Cookies()
        if(cookies.get("User")){
            console.log(cookies.get("User"))
            userHasAuthenticated(true);
        }
        setIsAuthenticating(false);
    }

    return (
        <div className="Header ">
            <Navbar collapseOnSelect bg="light" expand="md" className="mb-3">
                <Navbar.Brand className="font-weight-bold text-muted">
                    Scratch
                </Navbar.Brand>
                {isAuthenticated ? (
                    <Nav.Link onClick={handleLogout}>Logout</Nav.Link>
                ) : (
                    <>
                        <LinkContainer to="/login">
                            <Nav.Link>Login</Nav.Link>
                        </LinkContainer>
                    </>
                )}
                <Navbar.Toggle/>
            </Navbar>
            <AppContext.Provider value={{isAuthenticated, userHasAuthenticated}}>
                <Routes/>
            </AppContext.Provider>
        </div>
    );
}

export default App;