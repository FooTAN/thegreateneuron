import axios from 'axios';
import React, { useEffect, useState } from 'react'

export interface UseFetch {
    response: any;
    loading: boolean;
    error: boolean;
}

function useFetch(run: boolean, url: string) {
    const [response, setResponse] = useState({});
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);

    useEffect(() => {
        console.log("RUN: "+run)
        let mounted = true;
        const abortController = new AbortController();
        const signal = abortController.signal;
        if (run && mounted) {
          const fetchData = async () => {
            try {
              setLoading(true);
              const response = await axios.get(url);
              if (response.status === 200 && !signal.aborted) {
                setResponse(response.data);
              }
            } catch (err:any) {
              if (!signal.aborted) {
                setResponse(err);
                setError(true);
              }
            } finally {
              if (!signal.aborted) {
                setLoading(false);
              }
            }
          };
          fetchData();
        }
    
        return () => {
          mounted = false;
          abortController.abort();
        };
      }, [run, url]);
    
      return { response, loading, error };
}

export default useFetch
