import { AppBar, Box, Toolbar, Typography } from "@mui/material";

export default function Menu() {
    return (
        <Box>
            <AppBar position="static">
                <Toolbar>
                    <Typography variant="h6" component="div">
                        Forest
                    </Typography>
                </Toolbar>
            </AppBar>
        </Box>
    );
}
