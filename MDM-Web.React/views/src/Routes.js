import React from "react";
import { Route, Switch } from "react-router-dom";
import HomePage from "./Components/HomePage";
import Login from "./Login";
import NotFound from "./Components/NotFound";

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