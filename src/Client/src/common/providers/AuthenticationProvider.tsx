import { ReactNode } from "react";
import { useQueryStore } from "../../stores/queryStore";

export const AuthenticationProvider = ({ children }: { children: ReactNode }) => {
    const {
        identityStore: { useGet },
    } = useQueryStore();

    const { data: isAuthenticated, isLoading } = useGet();

    if (isLoading || isAuthenticated == undefined) {
        return null;
    }

    if (!isAuthenticated) {
        window.location.href = "/account/login";
    }

    return <>{children}</>;
};
