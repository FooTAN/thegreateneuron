import React, { useEffect, useState } from 'react';
import axios from 'axios';

function UsersView() {
    const [users, setUsers] = useState([]);

    useEffect(()=>{
        axios.get('/api/auth/users').then(response => {
            setUsers(response.data);
        });
    }, []);

  return (
      <div>
          Users
          <ul>
              {users.map((user: any) => (
              <li key={user.userName}>
                  {user.userName}
              </li>
              ))}
          </ul>
      </div>
  );
}

export default UsersView;
