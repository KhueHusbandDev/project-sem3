import { configureStore } from "@reduxjs/toolkit";
import chatRoomsSlice from "./chatRoomsSlice";
import userSlice from "./userSlice";

export default configureStore({
    reducer: {
        rooms: chatRoomsSlice,
        user: userSlice
    }
})