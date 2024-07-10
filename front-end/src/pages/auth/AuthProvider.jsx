import { Outlet, useNavigate } from "react-router-dom";
import { AuthService } from "../../services/auth/AuthServices";
import { createContext, useContext, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { setUser } from "../../redux/userSlice";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const dispatch = useDispatch()
  const user = useSelector((state)=> state.user);

  const navigate = useNavigate();

  const login = async (data) => {
    const res = await AuthService.login(data);

    if (res) {
      dispatch(setUser(user));
      navigate("/home/profile");
      return;
    }
    return null;
  };

  const logOut = () => {
    dispatch(setUser(null));
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
