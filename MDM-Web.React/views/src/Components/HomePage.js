import 'bootstrap'
import 'react-bootstrap'
import '../css/HomePage.css'
import React, {useEffect, useState} from "react";
import {useAppContext} from "../libs/contextLib";
import {LinkContainer} from "react-router-bootstrap";
import {ListGroup} from "react-bootstrap";


function HomePage() {
    const [devices, setDevices] = useState([])
    const {isAuthenticated} = useAppContext();
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        function onLoad() {
            if (!isAuthenticated) {
                return;
            }

            try {
                setDevices(loadDevices)
            } catch (e) {
                alert("Nie się pobrać listy urządzeń, odśwież stronę aby spróbować ponownie")
            }

            setIsLoading(false);
        }

        onLoad();
    }, [isAuthenticated]);

    function loadDevices() {
        return [{
            deviceID: 1,
            Name: "Urządzenie Filipa",
            SystemName: "IOS",
            SystemVersion: "13",
            Model: "Iphone 11",
            BatteryState: 99,
            BatteryLevel: 69
        }]
    }

    function renderDevicesList(devices) {
        return (
            <>
                {devices.map(({deviceID, Name, SystemName, SystemVersion, Model, BatteryState, BatteryLevel}) =>
                    <LinkContainer key={{deviceID}} to={`/devices/${deviceID}`}>
                        <ListGroup.Item action>
                            <span className="font-weight-bold">
                                {Name}
                            </span>
                        </ListGroup.Item>
                    </LinkContainer>
                )}
            </>

        )
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
            <div className="container">
                <div className="card">
                    <div className="row  pt-2 pb-2">
                        <div className="col-12 col-md-6">

                        </div>
                        <div className="col-12 col-md-6 text-right ">
                            <button className="btn btn-success m-1 ">Dodaj nowy</button>
                            <button className="btn btn-danger m-1">Usuń zaznaczone</button>
                        </div>
                    </div>
                    <div>{!isLoading && renderDevicesList(devices)}</div>
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