import 'bootstrap'
import 'react-bootstrap'
import Routes from "./Routes";
import Navbar from "react-bootstrap/Navbar";

function Header() {
    return (
        <div className="Header container py-3">
            <Navbar collapseOnSelect bg="light" expand="md" className="mb-3">
                <Navbar.Brand className="font-weight-bold text-muted">
                    Scratch
                </Navbar.Brand>
                <Navbar.Toggle />
            </Navbar>
            <Routes />
        </div>
    );
}

export default Header;