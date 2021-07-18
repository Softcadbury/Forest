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
                    <Route exact path="/">
                        <Trees />
                    </Route>
                    <Route path="/tree">
                        <Tree />
                    </Route>
                </Switch>
            </Suspense>
        </BrowserRouter>
    );
}

export default App;
