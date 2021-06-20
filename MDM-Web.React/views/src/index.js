import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Login from "./Login";
import reportWebVitals from './reportWebVitals';
import Header from "./Header";
import ConfigurationProfileDownload from "./Components/ConfigurationProfileDownload";
import HomePage from "./Components/HomePage";
import App from "./App";
import {BrowserRouter} from "react-router-dom";


ReactDOM.render(
    <React.StrictMode>
        <BrowserRouter>
            <App/>
        </BrowserRouter>
    </React.StrictMode>,
    document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();