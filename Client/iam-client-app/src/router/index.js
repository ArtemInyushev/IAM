import { createWebHistory, createRouter } from "vue-router";
import Auth from "../auth/index";

const routes = [
    {
        path: '/',
        name: 'Home',
        component: () => import('../views/MainView'),
        props: true,
        meta: {requiresAuth: true }
    },
    {
        path: '/Departments/:departmentId(\\d+)',
        name: 'Departments',
        component: () => import('../views/MainView'),
        props: true,
        meta: {requiresAuth: true }
    },
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
            console.log(err);
            await Auth.getToken();
            /*next({
                name: 'SignIn',
                query: {
                    nextUrl: to.fullPath,
                }
            });*/
            next();
        }
    }
    else{
        next();
    }
});

export default router;