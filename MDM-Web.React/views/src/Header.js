import 'bootstrap'
import 'react-bootstrap'

function Header() {
    return (
        <div className="container-fluid shadow-sm ">
            <div className="row">
                <div className="col-6 col-md-4 pt-2 pb-2">
                    <img src="https://via.placeholder.com/50"/>
                </div>
                <div className="col-6 col-md-8">
                    <ul className="navbar h-100">
                        <li className="nav-item">Test</li>
                        <li className="nav-item">Test</li>
                        <li className="nav-item">Test</li>
                    </ul>
                </div>
            </div>
        </div>
    );
}

export default Header;