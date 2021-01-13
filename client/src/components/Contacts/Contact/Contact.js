import React from 'react';
import { Card, CardActions, CardContent, Button, Typography, CardHeader, Avatar } from '@material-ui/core/';
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';
import MoreHorizIcon from '@material-ui/icons/MoreHoriz';
import moment from 'moment';
import { useDispatch } from 'react-redux';

import { deleteContact } from '../../../actions/contacts';
import useStyles from './styles';

const Contact = ({ contact, setCurrentId }) => {
  const dispatch = useDispatch();
  const classes = useStyles();
 
  return (
    <Card className={classes.card}>     
      <CardHeader
        avatar={
          <Avatar aria-label="recipe" className={classes.avatar}>
            {contact.firstName.substring(0, 1).toUpperCase()}{contact.surname.substring(0, 1).toUpperCase()}
          </Avatar>
        }
        title= {contact.firstName}
        subheader={moment(contact.birthDate).format("DD-MM-YYYY")}
      />
      <CardContent>
        <Typography variant="body2" color="textSecondary" component="p">{contact.message}</Typography>
      </CardContent>
      <CardActions className={classes.cardActions}>       
      <Button size="small" color="primary" onClick={() => setCurrentId(contact._id)}>
        <EditIcon fontSize="small" /> Edit</Button> 
        <Button size="small" color="primary" onClick={() => dispatch(deleteContact(contact._id))}>
          <DeleteIcon fontSize="small" /> Delete</Button>
      </CardActions>
    </Card>
  );
};

export default Contact;
