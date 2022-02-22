import { AppBar, Box, Toolbar, Typography } from "@mui/material";

export const Menu: React.FC = () => {
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
};
