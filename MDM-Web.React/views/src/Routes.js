import React from "react";
import { Route, Switch } from "react-router-dom";
import HomePage from "./Components/HomePage";
import Login from "./Login";

export default function Routes() {
    return (
        <Switch>
            <Route exact path="/">
                <Login />
            </Route>
        </Switch>
    );
}