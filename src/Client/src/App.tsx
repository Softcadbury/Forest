import { Box, Container, GlobalStyles } from "@mui/material";
import { Fragment, lazy, Suspense } from "react";
import { Routes, Route, BrowserRouter } from "react-router-dom";
import { Loader, Menu } from "./common/components";
import { AuthenticationProvider } from "./common/providers/AuthenticationProvider";
import { ResourcesProvider } from "./common/providers/ResourcesProvider";

const Tree = lazy(() => import("./pages/tree/Tree"));
const Trees = lazy(() => import("./pages/trees/Trees"));

const App: React.FC = () => {
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
                                    <Routes>
                                        <Route path="/trees/:id" element={<Tree />} />
                                        <Route path="/trees" element={<Trees />} />
                                        <Route path="*" element={<Trees />} />
                                    </Routes>
                                </Box>
                            </Container>
                        </Suspense>
                    </BrowserRouter>
                </ResourcesProvider>
            </AuthenticationProvider>
        </Fragment>
    );
};

export default App;
