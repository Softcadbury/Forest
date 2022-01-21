import { Box, CircularProgress, Container, createTheme, GlobalStyles } from "@mui/material";
import { Fragment, lazy, Suspense } from "react";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import { AuthenticationProvider } from "./common/providers/authentication-provider";
import Menu from "./common/components/menu/menu";

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
                <BrowserRouter>
                    <Suspense fallback={<CircularProgress />}>
                        <Menu />
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
            </AuthenticationProvider>
        </Fragment>
    );
}

export default App;
