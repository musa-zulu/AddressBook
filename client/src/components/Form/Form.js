import React, { useState, useEffect } from "react";
import {
  TextField,
  Button,
  Typography,
  Paper,
  Container,
  RadioGroup,
  Radio,
} from "@material-ui/core";
import { useDispatch, useSelector } from "react-redux";
import IconButton from "@material-ui/core/IconButton";
import RemoveIcon from "@material-ui/icons/Remove";
import AddIcon from "@material-ui/icons/Add";

import FormControlLabel from "@material-ui/core/FormControlLabel";
import FormControl from "@material-ui/core/FormControl";
import FormLabel from "@material-ui/core/FormLabel";

import useStyles from "./styles";
import { createContact, updateContact } from "../../actions/contacts";

const Form = ({ currentId, setCurrentId }) => {
  const [contactData, setContactData] = useState({
    firstName: "",
    surname: "",
    birthDate: "",
  });
  const [inputFields, setInputField] = useState([
    { address: "", telephone: "", cell: "", email: "", description: "" },
  ]);
  const contact = useSelector((state) =>
    currentId
      ? state.contacts.find((message) => message._id === currentId)
      : null
  );
  const dispatch = useDispatch();
  const classes = useStyles();

  useEffect(() => {
    if (contact) setContactData(contact);
  }, [contact]);

  const clear = () => {
    setCurrentId(0);
    setContactData({ firstName: "", surname: "", birthDate: "" });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (currentId === 0) {
      dispatch(createContact(contactData));
      clear();
    } else {
      dispatch(updateContact(currentId, contactData));
      clear();
    }
  };

  const handleAddFields = () => {
    setInputField([...inputFields, { address: "", telephone: "", cell: "", email: "", description: "" }]);
  }

  const handleRemoveFields = (index) => {
    const values = [...inputFields];
    values.splice(index);
    setInputField(values);
  }

  return (
    <Paper className={classes.paper}>
      <form
        autoComplete="off"
        noValidate
        className={`${classes.root} ${classes.form}`}
        onSubmit={handleSubmit}
      >
        <Typography variant="h6">
          {currentId ? `Editing "${contact.firstName}"` : "Creating a Contact"}
        </Typography>
        <TextField
          name="firstName"
          variant="outlined"
          label="First Name"
          fullWidth
          value={contactData.firstName}
          onChange={(e) =>
            setContactData({ ...contactData, firstName: e.target.value })
          }
        />
        <TextField
          name="surname"
          variant="outlined"
          label="Surname"
          fullWidth
          value={contactData.surname}
          onChange={(e) =>
            setContactData({ ...contactData, surname: e.target.value })
          }
        />
        <TextField
          name="birthDate"
          variant="outlined"
          type="date"
          label="Birth Date"
          fullWidth
          value={contactData.birthDate}
          onChange={(e) =>
            setContactData({ ...contactData, birthDate: e.target.value })
          }
          InputLabelProps={{ shrink: true }}
        />
        <Container>
          <form>
            {inputFields.map((inputField, index) => (
              <div key={index}>
                <FormControl component="fieldset">
                  <RadioGroup
                    row
                    aria-label="position"
                    name="position"
                    defaultValue="bottom"
                  >
                    <FormControlLabel
                      className={classes.formControlLabel}
                      value={inputField.address}
                      onChange={(e) =>
                        setInputField({
                          ...inputField,
                          address: e.target.value,
                        })
                      }
                      control={<Radio color="primary" />}
                      label="Address"
                      labelPlacement="bottom"
                    />
                    <FormControlLabel
                      className={classes.formControlLabel}
                      value={inputField.cell}
                      onChange={(e) =>
                        setInputField({ ...inputField, cell: e.target.value })
                      }
                      control={<Radio color="primary" />}
                      label="Cell"
                      labelPlacement="bottom"
                    />
                    <FormControlLabel
                      className={classes.formControlLabel}
                      value={inputField.email}
                      onChange={(e) =>
                        setInputField({ ...inputField, email: e.target.value })
                      }
                      control={<Radio color="primary" />}
                      label="Email"
                      labelPlacement="bottom"
                    />
                    <FormControlLabel
                      className={classes.formControlLabel}
                      value={inputField.telephone}
                      onChange={(e) =>
                        setInputField({
                          ...inputField,
                          telephone: e.target.value,
                        })
                      }
                      control={<Radio color="primary" />}
                      label="Telephone"
                      labelPlacement="bottom"
                    />
                  </RadioGroup>
                </FormControl>
                <TextField
                  className={classes.descriptionTextField}
                  name="description"
                  variant="outlined"
                  label="Description"
                  value={contactData.description}
                  onChange={(e) =>
                    setInputField({
                      ...inputField,
                      description: e.target.value,
                    })
                  }
                />
                <IconButton onClick={() => handleRemoveFields(index) }>
                  <RemoveIcon />
                </IconButton>
                <IconButton onClick={() => handleAddFields() }>
                  <AddIcon />
                </IconButton>
              </div>
            ))}
          </form>
        </Container>
        <Button
          className={classes.buttonSubmit}
          variant="contained"
          color="primary"
          size="large"
          type="submit"
          fullWidth
        >
          Submit
        </Button>
        <Button
          variant="contained"
          color="secondary"
          size="small"
          onClick={clear}
          fullWidth
        >
          Clear
        </Button>
      </form>
    </Paper>
  );
};

export default Form;
