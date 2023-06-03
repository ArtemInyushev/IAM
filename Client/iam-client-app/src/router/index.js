import { createWebHistory, createRouter } from "vue-router";
import Auth from "../auth/index";

const routes = [

];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

router.beforeEach(async (to, from, next) => {
    
    if (to.meta.requiresAuth) {
        try {
            await Auth.acquireTokenSilent();
            next();
        }
        catch (err) {
            console.log(err)
            /*next({
                name: 'SignIn',
                query: {
                    nextUrl: to.fullPath,
                }
            });*/
        }
    }
    else{
        next();
    }
});

export default router;