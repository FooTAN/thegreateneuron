import 'bootstrap/dist/css/bootstrap.css';
import '../styles/globals.css'
import type { AppProps } from 'next/app'

function AdminApp({ Component, pageProps }: AppProps) {
  return <Component {...pageProps} />
}
export default AdminApp
