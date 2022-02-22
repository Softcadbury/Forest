import { Box, Container, GlobalStyles } from "@mui/material";
import { Fragment, lazy, Suspense } from "react";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import { AuthenticationProvider } from "./common/providers/AuthenticationProvider";
import Menu from "./common/components/menu/Menu";
import { ResourcesProvider } from "./common/providers/ResourcesProvider";
import Loader from "./common/components/loader/Loader";

const Tree = lazy(() => import("./pages/tree/Tree"));
const Trees = lazy(() => import("./pages/trees/Trees"));

function App() {
    return (
        <Fragment>
            <GlobalStyles
                styles={{
                    body: { margin: 0, padding: 0 },
                }}
            />
            <AuthenticationProvider>
                <ResourcesProvider>
                    <BrowserRouter>
                        <Menu />
                        <Suspense fallback={<Loader />}>
                            <Container>
                                <Box padding={5}>
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
                                </Box>
                            </Container>
                        </Suspense>
                    </BrowserRouter>
                </ResourcesProvider>
            </AuthenticationProvider>
        </Fragment>
    );
}

export default App;
