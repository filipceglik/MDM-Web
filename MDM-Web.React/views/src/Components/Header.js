import 'bootstrap'
import 'react-bootstrap'
import Navbar from "react-bootstrap/Navbar";
import Routes from "../Routes";

function Header() {
    return (
        <div className="Header ">
                <Navbar collapseOnSelect bg="light" expand="md" className="mb-3">
                    <Navbar.Brand className="font-weight-bold text-muted">
                        Scratch
                    </Navbar.Brand>
                    <Navbar.Toggle/>
                </Navbar>
            <Routes/>
        </div>
    );
}

export default Header;