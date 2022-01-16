import { Box, Button, FormControl, Input, InputLabel, Modal } from "@material-ui/core";
import { useCallback, useState } from "react";
import { useTextField } from "../../../hooks/useTextField";
import { useQueryStore } from "../../../query-store/query-store";
import { TreePost } from "../../../services/generated-services";

interface AddTreeModalProperties {
    isOpen: boolean;
    handleClose: () => void;
}

const style = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 400,
    bgcolor: "background.paper",
    border: "2px solid #000",
    boxShadow: 24,
    p: 4,
};

function AddTreeModal({ isOpen, handleClose }: AddTreeModalProperties) {
    const { treeStore } = useQueryStore();
    const { mutate: onCreateTree } = treeStore.useCreate();
    const [treeLabel, , onTreeLabelChange] = useTextField();

    const onClickCreateTree = useCallback(() => {
        // todo handle bad arguments
        var tree = new TreePost({ label: treeLabel });
        onCreateTree(tree);
        handleClose();
    }, [handleClose, onCreateTree, treeLabel]);

    return (
        <Modal
            open={isOpen}
            onClose={handleClose}
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
        >
            <Box sx={style}>
                <FormControl>
                    <InputLabel htmlFor="my-input">Name</InputLabel>
                    <Input id="my-input" aria-describedby="my-helper-text" onChange={onTreeLabelChange} />
                </FormControl>
                <Button onClick={onClickCreateTree}>+ Add</Button>
            </Box>
        </Modal>
    );
}

export default AddTreeModal;
