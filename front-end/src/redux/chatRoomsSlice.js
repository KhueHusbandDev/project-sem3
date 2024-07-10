import { createSlice } from "@reduxjs/toolkit"

const initialState = {
    rooms: [],
    activeRoom: {},
}

const chatRoomsSlice = createSlice({
    name: "chats",
    initialState,
    reducers: {
        setActiveChat: (state, { payload }) => {
            state.activeRoom = payload;
        },
        removeUserFromChat: (state, { payload }) => {
            state.activeRoom = { ...state.activeRoom, users: state.activeRoom.users.filter(us => us.id !== payload) }
        },
        addUserToChat: (state, { payload }) => {
            state.activeRoom = { ...state.activeRoom, users: [...state.activeRoom.users, payload] }
        },
    }
})

export const { setActiveChat, removeUserFromChat, addUserToChat } = chatRoomsSlice.actions;
export default chatRoomsSlice.reducer;