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
        children: [
            {
                path: 'Roles',
                name: 'Roles',
                component: () => import('../views/RolesView'),
                props: true,
                children: [
                    {
                        path: 'CreateEntRole',
                        name: 'CreateEntRole',
                        component: () => import('../components/CreateEntRoleCard'),
                        props: true,
                        meta: {requiresAuth: true }
                    },
                    {
                        path: 'EntRoles/:entRoleId(\\d+)',
                        name: 'EntRoles',
                        component: () => import('../components/EntRoleCard'),
                        props: true,
                        meta: {requiresAuth: true }
                    },
                ],
                meta: {requiresAuth: true }
            },
            {
                path: 'Staffings',
                name: 'Staffings',
                component: () => import('../components/StaffingCard'),
                props: true,
                meta: {requiresAuth: true }
            },
            {
                path: 'Payroll/:personalId(\\d+)?',
                name: 'Payroll',
                component: () => import('../components/PayrollCard'),
                props: true,
                children: [
                    {
                        path: 'AllEntRoles',
                        name: 'AllEntRoles',
                        component: () => import('../components/PayrollRolesCard'),
                        props: true,
                        meta: {requiresAuth: true }
                    },
                    {
                        path: 'StaffingEntRoles',
                        name: 'StaffingEntRoles',
                        component: () => import('../components/PayrollRolesCard'),
                        props: true,
                        meta: {requiresAuth: true }
                    },
                    {
                        path: 'EntRolesNoBase',
                        name: 'EntRolesNoBase',
                        component: () => import('../components/PayrollRolesCard'),
                        props: true,
                        meta: {requiresAuth: true }
                    },
                    {
                        path: 'AllRoles',
                        name: 'AllRoles',
                        component: () => import('../components/PayrollRolesCard'),
                        props: true,
                        meta: {requiresAuth: true }
                    },
                ],
                meta: {requiresAuth: true }
            },
        ],
        meta: {requiresAuth: true }
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
    linkActiveClass: 'iam-nav-link-active'
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