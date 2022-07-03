import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { QueryClient, QueryClientProvider } from "react-query";

const queryClient = new QueryClient({
    defaultOptions: {
        queries: {
            staleTime: 300000,
            refetchOnMount: false,
            refetchOnWindowFocus: false,
            notifyOnChangeProps: "tracked",
        },
    },
});

const root = ReactDOM.createRoot(document.getElementById("root")!);
root.render(
    <React.StrictMode>
        <QueryClientProvider client={queryClient}>
            <App />
        </QueryClientProvider>
    </React.StrictMode>
);
