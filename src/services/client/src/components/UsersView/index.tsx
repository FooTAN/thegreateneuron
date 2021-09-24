import React, { useEffect, useState } from 'react';
import useFetch from '../../hooks/useFetch';
import { User, Users } from '../../models/user';

function UsersView() {
    const [shouldFetch, setShouldFetch] = useState(true);
    const [usersCollection, setUsersCollection] = useState<Users>();

    const {response} = useFetch(true, "/api/auth/users");

    useEffect(()=>{
        //var u = <User[]>JSON.parse(JSON.stringify(response));
        //console.log("FO: "+   response is User[]);¨
        setUsersCollection(response as Users);

    }, [shouldFetch]);

  return (
      <div>
          Users
          {console.log("Booooooo: "+ JSON.stringify(response))}
        {console.log("FOs: "+ JSON.stringify(usersCollection)+":"+usersCollection?.users.length)}
          <ul>
              {(usersCollection && usersCollection.users)&& usersCollection.users.map((user: User) => (
              <li key={user.userName}>
                  {user.userName}
              </li>
              ))}
          </ul>
      </div>
  );
}

export default UsersView;
