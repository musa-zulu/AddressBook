import React from 'react';
import { Grid, CircularProgress } from '@material-ui/core';
import { useSelector } from 'react-redux';

import Contact from './Contact/Contact';
import useStyles from './styles';

const Contacts = ({ setCurrentId }) => {
  const contacts = useSelector((state) => state.contacts);
  const classes = useStyles();

  return (
    !contacts.length ? <CircularProgress /> : (
      <Grid className={classes.container} container alignItems="stretch" spacing={3}>
        {contacts.map((contact) => (
          <Grid key={contact._id} item xs={12} sm={6} md={6}>
            <Contact contact={contact} setCurrentId={setCurrentId} />
          </Grid>
        ))}
      </Grid>
    )
  );
};

export default Contacts;
