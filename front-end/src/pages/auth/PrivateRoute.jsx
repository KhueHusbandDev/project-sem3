import { AppShell } from "@mantine/core";
import { Navigate, Outlet } from "react-router-dom";
import { Header } from "../layout/Header";
import { Navbar } from "../layout/NavBar";
import { useAuth } from "./AuthProvider";

const PrivateRoute = () => {
  const { user } = useAuth();
  if (!user) return <Navigate to="/" />;
  
  return (
    <AppShell
      header={{ height: 60 }}
      navbar={{
        width: 300,
        breakpoint: "sm",
      }}
      padding="md"
    >
      <AppShell.Header>
        <Header />
      </AppShell.Header>
      <AppShell.Navbar p="md">
        <Navbar />
      </AppShell.Navbar>
      <AppShell.Main>
        <Outlet />
      </AppShell.Main>
    </AppShell>
  );
};

export default PrivateRoute;
