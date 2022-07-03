import { Breadcrumbs, Button, Link } from "@mui/material";
import NavigateNextIcon from "@mui/icons-material/NavigateNext";
import AddIcon from "@mui/icons-material/Add";
import { useResources } from "../../../hooks";

interface TreeHeaderProps {
    onAdd: () => void;
    treeLabel?: string | undefined;
}

export const TreeHeader: React.FC<TreeHeaderProps> = ({ onAdd, treeLabel }) => {
    const resources = useResources();

    return (
        <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: "20px" }}>
            <Breadcrumbs separator={<NavigateNextIcon fontSize="small" />} aria-label="breadcrumb">
                <Link underline="hover" key="1" color="inherit" href="/">
                    {resources.common_Trees}
                </Link>
                {treeLabel && <span>{treeLabel}</span>}
            </Breadcrumbs>
            <Button sx={{ marginLeft: 3 }} startIcon={<AddIcon />} onClick={onAdd}>
                {resources.common_Add}
            </Button>
        </div>
    );
};
