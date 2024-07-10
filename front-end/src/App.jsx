import "./App.css";
import "@mantine/core/styles.css";
import { MantineProvider } from "@mantine/core";
import { Route, Routes } from "react-router-dom";

import AuthProvider from "./pages/auth/AuthProvider";
import Login from "./pages/auth/Login";
import { Register } from "./pages/auth/Register";
import { Layout } from "./pages/layout/Layout";

import Plans from "./pages/user/Plans";
import PrivateRoute from "./pages/auth/PrivateRoute";
import Profile from "./pages/user/profile/Profile";
import Chat from "./pages/user/chat/Chat";

function App() {
  return (
    <MantineProvider>
      <AuthProvider>
        <Routes>
          <Route index path="/" element={<Login />} />
          <Route path="register" element={<Register />} />
          <Route path="/home" element={<PrivateRoute />}>
            <Route path="chat" element={<Chat />} />
            <Route path="plans" element={<Plans />} />
            <Route path="profile" element={<Profile />} />
          </Route>
        </Routes>
      </AuthProvider>
    </MantineProvider>
  );
}

export default App;
