import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    id: '',
    username: '',
    imageURL: '',
    email: '',
    phoneNumber: '',
    plans: '',
}

const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        removeUser: (state) => {
            state.user = initialState;
        },
        setUser: (state, { payload }) => {
            state.user = { ...payload };
        },
    }
})

export const { removeUser, setUser } = userSlice.actions;
export default userSlice.reducer;