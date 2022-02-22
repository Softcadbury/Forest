import { Box, CircularProgress } from "@mui/material";

export const Loader: React.FC = () => {
    return (
        <Box sx={{ display: "flex", marginTop: "40px" }}>
            <Box sx={{ margin: "auto" }}>
                <CircularProgress />
            </Box>
        </Box>
    );
};
