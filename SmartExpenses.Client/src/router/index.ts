import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import UserView from '@/views/UserView.vue'
import ExpenseView from '@/views/ExpenseView.vue'
import {useAuth} from "@/utils/useAuth.ts";
import Login from "@/components/pages/Auth/Login.vue";
import Register from "@/components/pages/Auth/Register.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
      meta: { requiresAuth: true },
    },
    {
      path: '/expense',
      name: 'expense',
      component: ExpenseView,
      meta: { requiresAuth: true },
    },
    {
      path: '/user',
      name: 'user',
      component: UserView,
      meta: { requiresAuth: true },
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue'),
      meta: { requiresAuth: true },
    },
    {
      path: '/login',
      component: Login
    },
    {
      path: '/register',
      component: Register
    },
  ],
})

router.beforeEach(async (to, from, next) => {
  const { token, fetchUser, user } = useAuth()

  if (token.value && !user.value) {
    await fetchUser()
  }

  if (to.meta.requiresAuth && !token.value) {
    next('/login')
  } else {
    next()
  }
})

export default router
