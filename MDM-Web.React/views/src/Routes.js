import React from "react";
import { Route, Switch } from "react-router-dom";
import NotFound from "./Components/NotFound";
import Login from "./Components/Login";

export default function Routes() {
    return (
        <Switch>
            <Route exact path="/">
                <Login />
            </Route>
            {/* Finally, catch all unmatched routes */}
            <Route>
                <NotFound />
            </Route>
        </Switch>
    );
}