import { CircularProgress } from "@material-ui/core";
import { lazy, Suspense } from "react";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import { AuthenticationProvider } from "./common/authentication-provider";

const Tree = lazy(() => import("./pages/tree/Tree"));
const Trees = lazy(() => import("./pages/trees/Trees"));

function App() {
    return (
        <AuthenticationProvider>
            <BrowserRouter>
                <Suspense fallback={<CircularProgress />}>
                    <Switch>
                        <Route path="/trees/:id">
                            <Tree />
                        </Route>
                        <Route path="/trees">
                            <Trees />
                        </Route>
                        <Route exact path="/">
                            <Trees />
                        </Route>
                    </Switch>
                </Suspense>
            </BrowserRouter>
        </AuthenticationProvider>
    );
}

export default App;
