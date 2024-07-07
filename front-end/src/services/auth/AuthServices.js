import { redirect } from "react-router-dom";
import { toast } from "sonner";

export const AuthService = {
    login: async (data) => {
        try {
            //@Quan: Call Api
            return { id: "demo", username: "demo1", password: "demo1" }
            toast.success("Login Success")
            redirect("/home");
        } catch (error) {
            console.log(error);
            toast.error("Login Failed");
        }
    },
    register: async (data) => {
        try {
            //Call Api
        } catch (error) {
            console.log(error);
        }
    }
}