import { Outlet, useNavigate } from "react-router-dom";
import { AuthService } from "../../services/auth/AuthServices";
import { createContext, useContext, useState } from "react";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const navigate = useNavigate();

  const login = async (data) => {
    const res = await AuthService.login(data);

    if (res) {
      setUser(res);
      navigate("/home/profile");
      return;
    }
    return null;
  };

  const logOut = () => {
    setUser(null);
    navigate("/");
  };

  return (
    <AuthContext.Provider value={{ user, login, logOut }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;

export const useAuth = () => {
  return useContext(AuthContext);
};
