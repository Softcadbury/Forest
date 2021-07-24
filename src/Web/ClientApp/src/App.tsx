import { CircularProgress } from "@material-ui/core";
import { lazy, Suspense } from "react";
import { Switch, Route, BrowserRouter } from "react-router-dom";

const Tree = lazy(() => import("./pages/tree/Tree"));
const Trees = lazy(() => import("./pages/trees/Trees"));

function App() {
    return (
        <BrowserRouter>
            <Suspense fallback={<CircularProgress />}>
                <Switch>
                    <Route path="/trees/:uuid">
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
    );
}

export default App;
