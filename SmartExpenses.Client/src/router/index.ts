import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '@/views/HomeView.vue'
import SettingsView from '@/views/SettingsView.vue'
import ExpenseView from '@/views/ExpenseView.vue'
import Login from '@/components/pages/Auth/Login.vue'
import Register from '@/components/pages/Auth/Register.vue'
import { useAuthStore } from '@/stores/auth'

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
      path: '/settings',
      name: 'settings',
      component: SettingsView,
      meta: { requiresAuth: true, roles: ['Admin'] },
    },
    {
      path: '/about',
      name: 'about',
      component: () => import('../views/AboutView.vue'),
      meta: { requiresAuth: true },
    },
    {
      path: '/login',
      component: Login,
    },
    {
      path: '/register',
      component: Register,
    },
  ],
})

router.beforeEach(async (to, from, next) => {
  const auth = useAuthStore()

  // Make sure user is decoded if token is set but user is not yet available
  if (auth.token && !auth.user) {
    auth.fetchUser()
  }

  if (to.meta.requiresAuth && !auth.isAuthenticated) {
    return next('/login')
  }

  if (to.meta.roles && !auth.role.some(r => (to.meta.roles as string[]).includes(r))) {
    return next('/unauthorized')
  }

  next()
})

export default router
