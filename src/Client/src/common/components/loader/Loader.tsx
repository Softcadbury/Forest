import { Box, CircularProgress } from "@mui/material";

export default function Loader() {
    return (
        <Box sx={{ display: "flex", marginTop: "40px" }}>
            <Box sx={{ margin: "auto" }}>
                <CircularProgress />
            </Box>
        </Box>
    );
}
