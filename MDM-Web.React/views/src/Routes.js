import React from "react";
import { Route, Switch } from "react-router-dom";
import NotFound from "./Components/NotFound";
import Login from "./Components/Login";
import HomePage from "./Components/HomePage";
import Device from "./Components/Device";

export default function Routes() {
    return (
        <Switch>
            <Route exact path="/">
                <HomePage />
            </Route>
            <Route exact path="/login">
                <Login />
            </Route>
            <Route exact path="/device">
                <Device />
            </Route>
            {/* Finally, catch all unmatched routes */}
            <Route>
                <NotFound />
            </Route>
        </Switch>
    );
}