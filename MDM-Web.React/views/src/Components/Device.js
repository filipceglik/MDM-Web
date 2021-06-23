import React, {useState, useEffect} from "react";
import {useParams, useHistory} from "react-router-dom";

export default function Device() {
    const {id} = useParams();
    const history = useHistory()
    const [device, setDevice] = useState(null);

    useEffect(() => {
        function loadDevice() {
            return {
                deviceID: 1,
                Name: "Urządzenie Filipa",
                SystemName: "IOS",
                SystemVersion: "13",
                Model: "Iphone 11",
                BatteryState: 99,
                BatteryLevel: 69
            }
        }

        function onLoad() {
            try {
                const device = loadDevice();
                setDevice(device);
            } catch (e) {
                alert("Nie udało się wczytać urządzenia")
            }
        }

        onLoad();
    }, [id])

    return (
        <div className="Device">
            {device.Name}
        </div>
    )
}