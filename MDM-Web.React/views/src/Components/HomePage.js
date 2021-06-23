import 'bootstrap'
import 'react-bootstrap'
import '../css/HomePage.css'
import {useState} from "react";
import {useAppContext} from "../libs/contextLib";


function HomePage() {
    const [devices, setDevices] = useState([])
    const {isAuthenticated} = useAppContext();
    const [isLoading, setIsLoading] = useState(true);

    function renderDevicesList(devices) {
        return null
    }

    function renderLander() {
        return (
            <div className="landing-page">
                <h1>Best MDM on market</h1>
                <p className="text-muted">MDM system created by PAFIPI</p>
                <a className="btn btn-primary" href="/login">Login to continue</a>
            </div>
        )
    }

    function renderDevices() {
        return (
            <div className="container card">
                <div className="row card-header table-header pt-2 pb-2">
                    <div className="col-12 col-md-6">

                    </div>
                    <div className="col-12 col-md-6 text-right ">
                        <button className="btn btn-success m-1 ">Dodaj nowy</button>
                        <button className="btn btn-danger m-1">Usuń zaznaczone</button>
                    </div>
                </div>
                <div className="row card-body border-bottom">
                    <div className="col-3">
                        test
                    </div>
                    <div className="col-3">
                        test
                    </div>
                    <div className="col-3">
                        test
                    </div>
                    <div className="col-3">

                    </div>
                </div>
                <div className="row card-body border-bottom">
                    <div className="col-3">
                        test
                    </div>
                    <div className="col-3">
                        test
                    </div>
                    <div className="col-3">
                        test
                    </div>
                    <div className="col-3">

                    </div>
                </div>
            </div>
        )
    }
    return (
        <div className="Home">
            {isAuthenticated ? renderDevices() : renderLander()}
        </div>
    );
}

export default HomePage;